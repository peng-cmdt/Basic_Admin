const Layout = () => import("@/layout/index.vue");

export default {
  path: "/station",
  name: "station",
  component: Layout,
  redirect: "/station",
  meta: {
    icon: "lucide:baggage-claim",
    title: "站点管理",
    permissions: ["station"],
    rank: 0
  },
  children: [
    {
      path: "/station/list",
      name: "station_list",
      meta: {
        title: "站点列表",
        permissions: ["station.list"],
        showParent: true
      },
      component: () => import("@/views/station/list/index.vue")
    }
  ]
} as RouteConfigsTable;
