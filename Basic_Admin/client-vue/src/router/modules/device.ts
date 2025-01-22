const Layout = () => import("@/layout/index.vue");

export default {
  path: "/device",
  name: "device",
  component: Layout,
  redirect: "/device",
  meta: {
    icon: "hugeicons:algorithm",
    title: "设备列表",
    permissions: ["device"],
    rank: 0
  },
  children: [
    {
      path: "/device/list",
      name: "device_list",
      meta: {
        title: "设备列表",
        permissions: ["device.type"],
        showParent: true
      },
      component: () => import("@/views/devices/type/index.vue")
    }
  ]
} as RouteConfigsTable;
